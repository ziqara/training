-- phpMyAdmin SQL Dump
-- version 4.8.5
-- https://www.phpmyadmin.net/
--
-- Хост: localhost
-- Время создания: Мар 03 2026 г., 13:06
-- Версия сервера: 5.7.25
-- Версия PHP: 7.1.26

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET AUTOCOMMIT = 0;
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- База данных: `shoes_shop`
--

-- --------------------------------------------------------

--
-- Структура таблицы `orders`
--

CREATE TABLE `orders` (
  `number` int(11) NOT NULL,
  `dateoforder` datetime NOT NULL,
  `dateofdelivery` datetime NOT NULL,
  `pickup_point_id` int(11) NOT NULL,
  `user_login` varchar(255) NOT NULL,
  `code` int(11) NOT NULL,
  `status` varchar(255) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Дамп данных таблицы `orders`
--

INSERT INTO `orders` (`number`, `dateoforder`, `dateofdelivery`, `pickup_point_id`, `user_login`, `code`, `status`) VALUES
(1, '2025-02-27 00:00:00', '2025-04-20 00:00:00', 1, '1diph5e@tutanota.com', 901, 'Завершен'),
(2, '2022-09-28 00:00:00', '2025-04-21 00:00:00', 11, '94d5ous@gmail.com', 902, 'Завершен'),
(3, '2025-03-21 00:00:00', '2025-04-22 00:00:00', 2, 'uth4iz@mail.com', 903, 'Завершен'),
(4, '2025-02-20 00:00:00', '2025-04-23 00:00:00', 11, 'yzls62@outlook.com', 904, 'Завершен'),
(5, '2025-03-17 00:00:00', '2025-04-24 00:00:00', 2, '1diph5e@tutanota.com', 905, 'Завершен'),
(6, '2025-03-01 00:00:00', '2025-04-25 00:00:00', 15, '94d5ous@gmail.com', 906, 'Завершен'),
(7, '2025-02-28 00:00:00', '2025-04-26 00:00:00', 3, 'uth4iz@mail.com', 907, 'Завершен'),
(8, '2025-03-31 00:00:00', '2025-04-27 00:00:00', 19, 'yzls62@outlook.com', 908, 'Новый'),
(9, '2025-04-02 00:00:00', '2025-04-28 00:00:00', 5, '1diph5e@tutanota.com', 909, 'Новый'),
(10, '2025-04-03 00:00:00', '2025-04-29 00:00:00', 19, '1diph5e@tutanota.com', 910, 'Новый');

-- --------------------------------------------------------

--
-- Структура таблицы `order_items`
--

CREATE TABLE `order_items` (
  `id` int(11) NOT NULL,
  `order_number` int(11) NOT NULL,
  `product_articul` varchar(255) NOT NULL,
  `quantity` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Структура таблицы `pickuppoint`
--

CREATE TABLE `pickuppoint` (
  `id` int(11) NOT NULL,
  `postal_index` int(11) NOT NULL,
  `address` varchar(255) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Дамп данных таблицы `pickuppoint`
--

INSERT INTO `pickuppoint` (`id`, `postal_index`, `address`) VALUES
(1, 420151, 'г. Лесной, ул. Вишневая, 32'),
(2, 125061, 'г. Лесной, ул. Подгорная, 8'),
(3, 630370, 'г. Лесной, ул. Шоссейная, 24'),
(4, 400562, 'г. Лесной, ул. Зеленая, 32'),
(5, 614510, 'г. Лесной, ул. Маяковского, 47'),
(6, 410542, 'г. Лесной, ул. Светлая, 46'),
(7, 620839, 'г. Лесной, ул. Цветочная, 8'),
(8, 443890, 'г. Лесной, ул. Коммунистическая, 1'),
(9, 603379, 'г. Лесной, ул. Спортивная, 46'),
(10, 603721, 'г. Лесной, ул. Гоголя, 41'),
(11, 410172, 'г. Лесной, ул. Северная, 13'),
(12, 614611, 'г. Лесной, ул. Молодежная, 50'),
(13, 454311, 'г. Лесной, ул. Новая, 19'),
(14, 660007, 'г. Лесной, ул. Октябрьская, 19'),
(15, 603036, 'г. Лесной, ул. Садовая, 4'),
(16, 394060, 'г. Лесной, ул. Фрунзе, 43'),
(17, 410661, 'г. Лесной, ул. Школьная, 50'),
(18, 625590, 'г. Лесной, ул. Коммунистическая, 20'),
(19, 625683, 'г. Лесной, ул. 8 Марта'),
(20, 450983, 'г. Лесной, ул. Комсомольская, 26'),
(21, 394782, 'г. Лесной, ул. Чехова, 3'),
(22, 603002, 'г. Лесной, ул. Дзержинского, 28'),
(23, 450558, 'г. Лесной, ул. Набережная, 30'),
(24, 344288, 'г. Лесной, ул. Чехова, 1'),
(25, 614164, 'г. Лесной, ул. Степная, 30'),
(26, 394242, 'г. Лесной, ул. Коммунистическая, 43'),
(27, 660540, 'г. Лесной, ул. Солнечная, 25'),
(28, 125837, 'г. Лесной, ул. Шоссейная, 40'),
(29, 125703, 'г. Лесной, ул. Партизанская, 49'),
(30, 625283, 'г. Лесной, ул. Победы, 46'),
(31, 614753, 'г. Лесной, ул. Полевая, 35'),
(32, 426030, 'г. Лесной, ул. Маяковского, 44'),
(33, 450375, 'г. Лесной ул. Клубная, 44'),
(34, 625560, 'г. Лесной, ул. Некрасова, 12'),
(35, 630201, 'г. Лесной, ул. Комсомольская, 17'),
(36, 190949, 'г. Лесной, ул. Мичурина, 26');

-- --------------------------------------------------------

--
-- Структура таблицы `tovar`
--

CREATE TABLE `tovar` (
  `articul` varchar(255) NOT NULL,
  `name` varchar(255) NOT NULL,
  `unit` varchar(255) NOT NULL,
  `price` int(11) NOT NULL,
  `supplier` varchar(255) NOT NULL,
  `manufacturer` varchar(255) NOT NULL,
  `category` varchar(255) NOT NULL,
  `discount` int(11) NOT NULL,
  `stockquantity` int(11) NOT NULL,
  `description` text NOT NULL,
  `picture` varchar(255) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Дамп данных таблицы `tovar`
--

INSERT INTO `tovar` (`articul`, `name`, `unit`, `price`, `supplier`, `manufacturer`, `category`, `discount`, `stockquantity`, `description`, `picture`) VALUES
('B320R5', 'Туфли', 'шт.', 4300, 'Kari', 'Rieker', 'Женская обувь', 2, 6, 'Туфли Rieker женские демисезонные, размер 41, цвет коричневый', '9.jpg'),
('B431R5', 'Ботинки', 'шт.', 2700, 'Обувь для вас', 'Rieker', 'Мужская обувь', 2, 5, 'Мужские кожаные ботинки/мужские ботинки', ''),
('C436G5', 'Ботинки', 'шт.', 10200, 'Kari', 'Alessio Nesca', 'Женская обувь', 15, 9, 'Ботинки женские, ARGO, размер 40', ''),
('D268G5', 'Туфли', 'шт.', 4399, 'Обувь для вас', 'Rieker', 'Женская обувь', 3, 12, 'Туфли Rieker женские демисезонные, размер 36, цвет коричневый', ''),
('D329H3', 'Полуботинки', 'шт.', 1890, 'Обувь для вас', 'Alessio Nesca', 'Женская обувь', 4, 4, 'Полуботинки Alessio Nesca женские 3-30797-47, размер 37, цвет: бордовый', '8.jpg'),
('D364R4', 'Туфли', 'шт.', 12400, 'Kari', 'Kari', 'Женская обувь', 16, 5, 'Туфли Luiza Belly женские Kate-lazo черные из натуральной замши', ''),
('D572U8', 'Кроссовки', 'шт.', 4100, 'Обувь для вас', 'Рос', 'Мужская обувь', 3, 6, '129615-4 Кроссовки мужские', '6.jpg'),
('E482R4', 'Полуботинки', 'шт.', 1800, 'Kari', 'Kari', 'Женская обувь', 2, 14, 'Полуботинки kari женские MYZ20S-149, размер 41, цвет: черный', ''),
('F427R5', 'Ботинки', 'шт.', 11800, 'Обувь для вас', 'Rieker', 'Женская обувь', 15, 11, 'Ботинки на молнии с декоративной пряжкой FRAU', ''),
('F572H7', 'Туфли', 'шт.', 2700, 'Kari', 'Marco Tozzi', 'Женская обувь', 2, 14, 'Туфли Marco Tozzi женские летние, размер 39, цвет черный', '7.jpg'),
('F635R4', 'Ботинки', 'шт.', 3244, 'Обувь для вас', 'Marco Tozzi', 'Женская обувь', 2, 13, 'Ботинки Marco Tozzi женские демисезонные, размер 39, цвет бежевый', '2.jpg'),
('G432E4', 'Туфли', 'шт.', 2800, 'Kari', 'Kari', 'Женская обувь', 3, 15, 'Туфли kari женские TR-YR-413017, размер 37, цвет: черный', '10.jpg'),
('G531F4', 'Ботинки', 'шт.', 6600, 'Kari', 'Kari', 'Женская обувь', 12, 9, 'Ботинки женские зимние ROMER арт. 893167-01 Черный', ''),
('G783F5', 'Ботинки', 'шт.', 5900, 'Kari', 'Рос', 'Мужская обувь', 2, 8, 'Мужские ботинки Рос-Обувь кожаные с натуральным мехом', '4.jpg'),
('H535R5', 'Ботинки', 'шт.', 2300, 'Обувь для вас', 'Rieker', 'Женская обувь', 2, 7, 'Женские Ботинки демисезонные', ''),
('H782T5', 'Туфли', 'шт.', 4499, 'Kari', 'Kari', 'Мужская обувь', 4, 5, 'Туфли kari мужские классика MYZ21AW-450A, размер 43, цвет: черный', '3.jpg'),
('J384T6', 'Ботинки', 'шт.', 3800, 'Обувь для вас', 'Rieker', 'Мужская обувь', 2, 16, 'B3430/14 Полуботинки мужские Rieker', '5.jpg'),
('J542F5', 'Тапочки', 'шт.', 500, 'Kari', 'Kari', 'Мужская обувь', 13, 0, 'Тапочки мужские Арт.70701-55-67син р.41', ''),
('K345R4', 'Полуботинки', 'шт.', 2100, 'Обувь для вас', 'CROSBY', 'Мужская обувь', 2, 3, '407700/01-02 Полуботинки мужские CROSBY', ''),
('K358H6', 'Тапочки', 'шт.', 599, 'Kari', 'Rieker', 'Мужская обувь', 20, 2, 'Тапочки мужские син р.41', ''),
('L754R4', 'Полуботинки', 'шт.', 1700, 'Kari', 'Kari', 'Женская обувь', 2, 7, 'Полуботинки kari женские WB2020SS-26, размер 38, цвет: черный', ''),
('M542T5', 'Кроссовки', 'шт.', 2800, 'Обувь для вас', 'Rieker', 'Мужская обувь', 18, 3, 'Кроссовки мужские TOFA', ''),
('N457T5', 'Полуботинки', 'шт.', 4600, 'Kari', 'CROSBY', 'Женская обувь', 3, 13, 'Полуботинки Ботинки черные зимние, мех', ''),
('O754F4', 'Туфли', 'шт.', 5400, 'Обувь для вас', 'Rieker', 'Женская обувь', 4, 18, 'Туфли женские демисезонные Rieker артикул 55073-68/37', ''),
('P764G4', 'Туфли', 'шт.', 6800, 'Kari', 'CROSBY', 'Женская обувь', 15, 15, 'Туфли женские, ARGO, размер 38', ''),
('S213E3', 'Полуботинки', 'шт.', 2156, 'Обувь для вас', 'CROSBY', 'Мужская обувь', 3, 6, '407700/01-01 Полуботинки мужские CROSBY', ''),
('S326R5', 'Тапочки', 'шт.', 9900, 'Обувь для вас', 'CROSBY', 'Мужская обувь', 17, 15, 'Мужские кожаные тапочки \"Профиль С.Дали\"', ''),
('S634B5', 'Кеды', 'шт.', 5500, 'Обувь для вас', 'CROSBY', 'Мужская обувь', 3, 0, 'Кеды Caprice мужские демисезонные, размер 42, цвет черный', ''),
('T324F5', 'Сапоги', 'шт.', 4699, 'Kari', 'CROSBY', 'Женская обувь', 2, 5, 'Сапоги замша Цвет: синий', ''),
('А112Т4', 'Ботинки', 'шт.', 4990, 'Kari', 'Kari', 'Женская обувь', 3, 6, 'Женские Ботинки демисезонные kari', '1.jpg');

-- --------------------------------------------------------

--
-- Структура таблицы `user`
--

CREATE TABLE `user` (
  `login` varchar(255) NOT NULL,
  `name` varchar(255) NOT NULL,
  `role` varchar(255) NOT NULL,
  `password` varchar(255) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Дамп данных таблицы `user`
--

INSERT INTO `user` (`login`, `name`, `role`, `password`) VALUES
('1diph5e@tutanota.com', 'Степанов Михаил Артёмович', 'Менеджер', '8ntwUp'),
('1qz4kw@mail.com', 'Ворсин Петр Евгеньевич', 'Авторизированный клиент', 'gynQMT'),
('4np6se@mail.com', 'Старикова Елена Павловна', 'Авторизированный клиент', 'AtnDjr'),
('5d4zbu@tutanota.com', 'Михайлюк Анна Вячеславовна', 'Авторизированный клиент', 'rwVDh9'),
('94d5ous@gmail.com', 'Никифорова Весения Николаевна', 'Администратор', 'uzWC67'),
('ptec8ym@yahoo.com', 'Ситдикова Елена Анатольевна', 'Авторизированный клиент', 'LdNyos'),
('tjde7c@yahoo.com', 'Ворсин Петр Евгеньевич', 'Менеджер', 'YOyhfR'),
('uth4iz@mail.com', 'Сазонов Руслан Германович', 'Администратор', '2L6KZG'),
('wpmrc3do@tutanota.com', 'Старикова Елена Павловна', 'Менеджер', 'RSbvHv'),
('yzls62@outlook.com', 'Одинцов Серафим Артёмович', 'Администратор', 'JlFRCZ');

--
-- Индексы сохранённых таблиц
--

--
-- Индексы таблицы `orders`
--
ALTER TABLE `orders`
  ADD PRIMARY KEY (`number`),
  ADD KEY `orders_ibfk_1` (`pickup_point_id`),
  ADD KEY `orders_ibfk_2` (`user_login`);

--
-- Индексы таблицы `order_items`
--
ALTER TABLE `order_items`
  ADD PRIMARY KEY (`id`),
  ADD KEY `order_items_ibfk_1` (`order_number`),
  ADD KEY `order_items_ibfk_2` (`product_articul`);

--
-- Индексы таблицы `pickuppoint`
--
ALTER TABLE `pickuppoint`
  ADD PRIMARY KEY (`id`);

--
-- Индексы таблицы `tovar`
--
ALTER TABLE `tovar`
  ADD PRIMARY KEY (`articul`);

--
-- Индексы таблицы `user`
--
ALTER TABLE `user`
  ADD PRIMARY KEY (`login`);

--
-- AUTO_INCREMENT для сохранённых таблиц
--

--
-- AUTO_INCREMENT для таблицы `order_items`
--
ALTER TABLE `order_items`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=21;

--
-- AUTO_INCREMENT для таблицы `pickuppoint`
--
ALTER TABLE `pickuppoint`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=37;

--
-- Ограничения внешнего ключа сохраненных таблиц
--

--
-- Ограничения внешнего ключа таблицы `orders`
--
ALTER TABLE `orders`
  ADD CONSTRAINT `orders_ibfk_1` FOREIGN KEY (`pickup_point_id`) REFERENCES `pickuppoint` (`id`) ON UPDATE CASCADE,
  ADD CONSTRAINT `orders_ibfk_2` FOREIGN KEY (`user_login`) REFERENCES `user` (`login`) ON UPDATE CASCADE;

--
-- Ограничения внешнего ключа таблицы `order_items`
--
ALTER TABLE `order_items`
  ADD CONSTRAINT `order_items_ibfk_1` FOREIGN KEY (`order_number`) REFERENCES `orders` (`number`) ON DELETE CASCADE ON UPDATE CASCADE,
  ADD CONSTRAINT `order_items_ibfk_2` FOREIGN KEY (`product_articul`) REFERENCES `tovar` (`articul`) ON UPDATE CASCADE;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
