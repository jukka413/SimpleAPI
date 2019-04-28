API с использованием MassTransit

Для просмотра строчки-примера из файла BD, после сборки и запуска:
https://localhost:5001/api/user/15b12ce0-8e52-48ea-beef-1b62a05439fe

Предварительно нужно поставить:
-Erlang
-RabbitMQ

Если ругается на сертификат - из терминала запускаем:
dotnet dev-certs https --trust

Если не дает добавить в Startup services.AddMassTransi:
https://stackoverflow.com/questions/47954136/masstransit-and-net-core-di-how-to-resolve-dependencies-with-parameterless-co

Неплохой ГУИ для postgres (можно коннектиться и к другим БД):
https://dbeaver.io/

ГУИ для RabbitMQ:
https://www.rabbitmq.com/management.html

Для тестирования PUT-запросов использовался postman:
https://www.getpostman-beta.com/
Если postman не будет пропускать запросы - нужно в его настройках убрать проверку SSL-сертов

Документация по MassTransit:
http://masstransit-project.com/

Статья на хабре про MassTransit:
https://habr.com/ru/post/210428/

Лекция про MassTransit Яндекс-Академии. Системы обмена сообщениями на примере MassTransit - Яков Повар:
https://www.youtube.com/watch?v=3j7ZJ1JSAHU&t=1460s
