
//Для корзины
async function updateCartCount() {
    try {
        const response = await fetch('/Cart/GetCartCount', { method: 'GET' });

        // Проверяем, что ответ успешный
        if (response.ok) {
            // Получаем количество товаров в корзине
            const count = await response.json();

            // Обновляем отображаемое количество в элементе с id 'cart-count'
            document.getElementById('cart-count').textContent = count;
        } else {
            console.error('Ошибка при получении количества товаров в корзине');
        }
    } catch (error) {
        console.error('Произошла ошибка:', error);
    }
}

// Обновляем количество товаров при загрузке страницы
document.addEventListener('DOMContentLoaded', function () {
    if (document.cookie.includes('tasty-cookies')) {
        // Если клиент авторизован, вызываем функцию updateCartCount
        updateCartCount();
    }
});
function addToCart(productId) {
    fetch('/Cart/add', {
        method: 'Post',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(productId)
    }).then(response => {
        if (response.ok) {
            alert('Товар добавлен в корзину');
            updateCartCount(); // Обновляем счетчик корзины
        } else {
            alert('Ошибка при добавлении товара');
        }
    });
}

//Функция поиска
function searchFunction() {
    const input = document.getElementById('search-input');
    const searchText = input.value;

    // Если поле пустое, не производим поиск
    if (searchText === "") {
        alert("Введите текст для поиска.");
        return;
    }

    // Вызов встроенной функции поиска браузера
    const found = window.find(searchText);

    // Если текст не найден, выводим сообщение
    if (!found) {
        alert("Совпадений не найдено.");
    }
}

// Функция для выхода пользователя
async function logout() {
    try {
        await fetch('/Client/logout', { method: 'POST' });  // Предполагается, что есть метод выхода
        location.reload();  // Перезагружаем страницу после выхода
    } catch (error) {
        console.error("Ошибка при выходе:", error);
    }
}

//Слайдер
let currentIndex = 0;

function showSlide(index) {
    const slides = document.querySelector('.slides');
    const totalSlides = slides.children.length;
    // Обновление индекса
    if (index < 0) {
        currentIndex = totalSlides - 1;
    } else if (index >= totalSlides) {
        currentIndex = 0;
    } else {
        currentIndex = index;
    }

    // Смещение слайдов
    slides.style.transform = `translateX(-${currentIndex * 100}%)`;

}

function prevSlide() {
    showSlide(currentIndex - 1);
}

function nextSlide() {
    showSlide(currentIndex + 1);
}

// Initialize indicators
document.addEventListener("DOMContentLoaded", () => {
    showSlide(currentIndex);
});

//Для корзины
function showCartModal() {
    const cartModal = document.getElementById("cartModal");
    cartModal.style.display = "block";
    loadCartItems(); // Загрузить содержимое корзины
}

function hideCartModal() {
    const cartModal = document.getElementById("cartModal");
    cartModal.style.display = "none";
}
function loadCartItems() {
    fetch('/Cart/GetCartItems', {
        method: 'GET',
        headers: {
            'Content-Type': 'application/json'
        }
    })
        .then(response => {
            if (!response.ok) {
                throw new Error(`Ошибка HTTP: ${response.status}`);
            }
            return response.json();
        })
        .then(data => {
            const cartItemsContainer = document.getElementById("cartItems");

            if (!data.products || !Array.isArray(data.products)) {
                throw new Error('Items не является массивом');
            }

            if (!data.products || data.products.length === 0) {
                cartItemsContainer.innerHTML = `<div class="cartItemsEmpty">Ваша корзина пуста.</div>`;
                return;
            }

            // Очищаем контейнер перед добавлением элементов
            cartItemsContainer.innerHTML = '';

            // Используем цикл for для обработки данных
            for (let i = 0; i < data.products.length; i++) {
                const item = data.products[i];

                const itemHtml = `
                    <div class="cart-item">
                        <span class="product-name">${item.productName}</span>
                        <span class="product-quantity"> ${item.сountOfProduct} шт.</span>
                        <span class="product-total-price">Итого: ${item.сost * item.сountOfProduct} ₽</span>
                        <div class="cart-actions">
                            <button class="remove-item" onclick="removeCartItem('${item.productId}')">-</button>
                            <button class="add-item" onclick="addToCartAndLoad('${item.productId}')">+</button>
                        </div>
                    </div>
                `;

                // Добавляем элемент в контейнер
                cartItemsContainer.innerHTML += itemHtml;
            }

            // Итоговая стоимость
            const totalCostHtml = `
                <div class="cart-item">
                    <span class="product-total-price">Итоговая стоимость: ${data.endCost} ₽</span>
                </div>
            `;
            cartItemsContainer.innerHTML += totalCostHtml;

        })
        .catch(error => {
            console.error('Ошибка загрузки корзины:', error);
        });
}

function addToCartAndLoad(productId) {
    fetch('/Cart/add', {
        method: 'Post',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(productId)
    }).then(response => {
        if (response.ok) {
            updateCartCount(); // Обновляем счетчик корзины
            loadCartItems(); // Перезагружаем содержимое корзины
        } else {
            alert('Ошибка при добавлении товара');
        }
    });
}

function removeCartItem(productId) {
    fetch('/Cart/DeleteProduct', {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(productId) // Передаем только ID товара
    })
        .then(response => {
            if (!response.ok) throw new Error('Ошибка при удалении товара');
            updateCartCount();
            loadCartItems(); // Перезагружаем содержимое корзины
        })
        .catch(error => {
            console.error('Ошибка:', error);
        });
}

//СУПЕР ПОИСК ОТ ЗУЙКИНА
document.addEventListener("DOMContentLoaded", function () {
    const searchInput = document.getElementById("searchInput");
    const searchResults = document.getElementById("searchResults");
    const resultsList = document.getElementById("resultsList");
    const clearButton = document.getElementById("clearButton");

    // Показать окно результатов поиска
    searchInput.addEventListener("input", function () {
        const query = searchInput.value.trim();

        if (query.length > 0) {
            fetch(`/Search/SearchRoute?query=${encodeURIComponent(query)}`)
                .then(response =>  response.json())
                .then(data => {
                    resultsList.innerHTML = ""; // Очистить предыдущие результаты
                    if (data.length > 0) {
                        data.forEach(item => {
                            const li = document.createElement("li");
                            const link = document.createElement("a");
                            link.href = item.linkText; // Используем маршрут из модели
                            link.textContent = item.searchText; // Имя страницы
                            li.appendChild(link);
                            resultsList.appendChild(li);
                        });
                    } else {
                        resultsList.innerHTML = "<li>Результатов не найдено</li>";
                    }
                    searchResults.style.display = "block"; // Показать окно
                });
        } else {
            searchResults.style.display = "none"; // Скрыть окно, если нет текста
        }
    });

    // Закрыть окно результатов при клике вне области
    document.addEventListener("click", function (e) {
        if (!searchResults.contains(e.target) && e.target !== searchInput) {
            searchResults.style.display = "none";
        }
    });

    // Кнопка очистки поиска
    clearButton.addEventListener("click", function () {
        searchInput.value = "";
        resultsList.innerHTML = "";
        searchResults.style.display = "none";
    });
});

// Функция скрытия результатов
function hideSearchResults() {
    const searchResults = document.getElementById("searchResults");
    searchResults.style.display = "none";
}
