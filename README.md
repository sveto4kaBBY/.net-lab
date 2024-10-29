Приложение фитнес-клуба

 В системе есть 2 пользователя администратор и клиент(пользователь). Администратор имеет возможность изменения занятий, пользователь может изменять только свои записи, он может выбрать интересующее его занятие и записаться на него или удалить запись. Подробные функциональные требования приложения ниже.

 Функциональные требования:
 
1 Регистрация пользователя
  - Пользователь должен иметь возможность зарегистрироваться, указав следующие данные:
  - Имя
  - Фамилия
  - Телефон (должен быть уникальным)
  - Пароль 
  - Номер карты
  - После успешной регистрации пользователю должно быть отправлено письмо с подтверждением.
  
2 Логин и логаут пользователя
  - Пользователь должен иметь возможность войти в приложение, введя номер карты/номер телефона и пароль.
  - В случае неверных данных должна отображаться соответствующая ошибка.
  - Пользователь должен иметь возможность выйти из своего аккаунта.
    
3 Просмотр списка записей (INDEX)
  - Пользователь должен иметь доступ к списку всех записей, связанных с его тренировками, занятиями или расписанием.
  - Записи должны отображаться в виде списка с краткой информацией (дата, время, тип занятия).
  - Должна быть возможность фильтрации записей по дате, типу занятия и статусу (записан/не записан).

4 Создание записи (CREATE)
  - Администратор должен иметь возможность создать новую запись, указав:
  - Тип занятия (например, йога, силовая тренировка)
  - Дата и время занятия
  - Продолжительность занятия
  - Описание занятия (опционально)
  - После создания записи пользователь должен увидеть уведомление об успешном добавлении.

5 Просмотр деталей записи (READ)
  - Пользователь должен иметь возможность выбрать запись из списка и просмотреть её детали.
  - Должны отображаться все поля записи, включая дату, время, тип занятия, описание и статус записи.

6 Редактирование записи (UPDATE)
  - Администратор должен иметь возможность редактировать записи.
  - При редактировании должны быть доступны все поля для изменения.
  - После успешного редактирования пользователь должен увидеть уведомление об обновлении.

7 Удаление записи (DELETE)
  - Пользователь должен иметь возможность удалить свою запись.
  - Администратор должен иметь возможность удалить запись.
  - При удалении должна появляться подтверждающая диалоговое окно для предотвращения случайного удаления.
  - После успешного удаления пользователь должен получить уведомление об этом.

  
![image](https://github.com/user-attachments/assets/186b5fdf-d63b-4d97-8111-ee3640be194f)

