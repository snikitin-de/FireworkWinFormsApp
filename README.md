# 🎮 FireworkWinFormsApp

🎮 :fireworks: Игра «Салют», написанная в процессе изучения технологии **Windows Forms** в рамках моделирования реальных процессов, работы со звуками и изучения принципов **ООП**.

<div align="center"><img src="https://github.com/snikitin-de/FireworkWinFormsApp/assets/25394427/6b46763a-277e-4d0f-9b69-c89740598057"></div>

## 📄 Описание

Из заданной точки (щелчок мыши) вылетают несколько шариков в случайных направлениях. Под действием силы тяжести падают вниз.

### :question: Правила игры

1. Клик левой кнопкой мыши на пустой области программы "взрывает" салют в точке клика мыши.
2. Клик правой кнопкой мыши в случайной точке запускает шарик, который взрывается на случайной высоте.

### 🎮 Геймплей

Пример геймплея игры:

![Пример геймплея игры](https://github.com/snikitin-de/FireworkWinFormsApp/assets/25394427/a3421389-032b-422a-bc5d-90e27316cbb6)

## 🔧 Техническая часть

* Проект реализован на платформе **Windows Forms**.
* Выполнен с соблюдением принципов **ООП**.
* Для работы со звуками используется библиотека **SoundPlayer**.

### 🧩 Архитектура

Структура каталога решения:

![Структура каталога решения](https://github.com/snikitin-de/FireworkWinFormsApp/assets/25394427/0b2df902-35cb-4f1e-9cc7-3ff952e3d626)

Проект "Common" является общей библиотекой классов для следующих проектов:

* [BallGamesWinFormsApp](https://github.com/snikitin-de/BallGamesWinFormsApp)
* [DiffusionWinFormsApp](https://github.com/snikitin-de/DiffusionWinFormsApp)
* [FruitNinjaWinFormsApp](https://github.com/snikitin-de/FruitNinjaWinFormsApp)
* [FireworkWinFormsApp](https://github.com/snikitin-de/FireworkWinFormsApp)

Библиотека содержит общий класс "Ball" от которого наследуются другие шарики со своими особенностями.
