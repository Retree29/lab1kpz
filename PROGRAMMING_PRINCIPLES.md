## 1) Single Responsibility Principle (SRP)
- `ProjectTask` відповідає за модель задачі та її інваріанти:
  https://github.com/Retree29/lab1kpz/blob/main/Program.cs#L52-L79
- `ConsoleNotifier` відповідає лише за повідомлення у консоль:
  https://github.com/Retree29/lab1kpz/blob/main/Program.cs#L91-L97
- `ConsoleTaskPrinter` відповідає лише за відображення списку задач:
  https://github.com/Retree29/lab1kpz/blob/main/Program.cs#L99-L110
- `TaskService` керує сценаріями роботи із задачами:
  https://github.com/Retree29/lab1kpz/blob/main/Program.cs#L8-L50

## 2) Dependency Inversion Principle (DIP)
- `TaskService` залежить від абстракцій `INotifier` та `ITaskPrinter`:
  https://github.com/Retree29/lab1kpz/blob/main/Program.cs#L10-L17
- Визначення абстракцій:
  https://github.com/Retree29/lab1kpz/blob/main/Program.cs#L81-L89

## 3) KISS
- Простий сценарій у стартовій частині програми:
  https://github.com/Retree29/lab1kpz/blob/main/Program.cs#L1-L6
- Лаконічні методи сервісу:
  https://github.com/Retree29/lab1kpz/blob/main/Program.cs#L20-L49

## 4) DRY
- Уніфіковані повідомлення через `INotifier.Notify`:
  https://github.com/Retree29/lab1kpz/blob/main/Program.cs#L81-L97

## Issues та Pull Requests (виконано)
- Issue #1: https://github.com/Retree29/lab1kpz/issues/1
  - PR #4 (Closes #1): https://github.com/Retree29/lab1kpz/pull/4
- Issue #2: https://github.com/Retree29/lab1kpz/issues/2
  - PR #5 (Closes #2): https://github.com/Retree29/lab1kpz/pull/5
- Issue #3: https://github.com/Retree29/lab1kpz/issues/3
  - PR #6 (Closes #3): https://github.com/Retree29/lab1kpz/pull/6
