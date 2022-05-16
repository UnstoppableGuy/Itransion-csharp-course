# Itransition course work.

- Требуется разработать сайт для управления личными коллекциями (книги, марки, значки, виски, etc. — далее в тексте то, из чего состоит коллекция, называется айтемами). 

- Неаутентифицированным пользователи доступен только режим read-only (доступен поиск, недоступно создание коллекий и айтемов, недоступны комментарии и лайки). 

- Аутентифицированные пользователи имеют доступ ко всему, кроме админки. Админка позволяет управлять пользователями (просматривать, блокировать, удалять, назначать других админами). 

- Администратор видит каждую страницу пользователя и каждую коллекцию как ее создатель-владелей (например, может отредактировать или создать от имени пользователя с его страницы новую коллекцию или добавить айтем и т.п.).

- Только владелец или админ может управлять коллекцией (редактировать/добавлять/удалять). 

- Вход через регистрацию на сайте. 

- На каждой странице доступен полнотекстовый поиск по сайту (результаты поиска - всегда айтемы, например, если текст найден в описании коллекции или комментарии, что должно быть возможно, то выводится ссылка на айтем). 

- У каждого пользователя есть его личная страница, на которой он управляет списком своих коллекий (можно добавить, удалить или отредактировать) и из которой можно перейти на страницу коллекции (там таблица с фильтраций и сортировками, возможность создать/удалить/редактировать айтем)

- Каждая коллекцяя состоит из: название, краткое описание с поддержкой форматирования markdown, "тема" (из фиксированного набора, например, "Alcohol", "Books" и проч.), опционального изображения (хранится в облаке, загружается drag-n-drop-ом).

- Помимо этого, у коллекции есть возможность указать поля, которые будут у каждого айтема в ней (есть фиксированные поля - id, название и тэги, можно "добавить" некоторые из следующих - три числовых поля, три строковых поля, три текстовых поля, три даты, три булевских чек-бокса). 

Например, можно указать, что в моей коллекции книг у каждого айтема есть (помимо id, названия и тэгов) строковое поле "Автор", текстовое поле "Комментарий", поле-дата "Год издания". Текстовое поле — поле с форматирование markdown. Поля характиризуются названием. Поля отображаются в списке айтемов - в списке необходима поддержка переключающихся сортировок и фильтров. Каждый айтем имеет тэги (вводится несколько тэгов, необходимо автодополнение - когда пользователь начинает вводить тэг, выпадает список с вариантами слов, которые уже вводились ранее на сайте) На главной странице отображаются: последние добавленные айтемы, коллекции с самым большим числом айтемов, облако тэгов (при клике результат - список ссылок на айтемы, аналогично результатам поиска, по сути это может быть одна вьюшка). При открытии айтема в режиме чтения автором или просто другими пользователями, в конце отображаются комментарии. Комментарии линейные, нельзя комментировать комментариий, новый добавляется только "в хвост". Необходимо реализовать автоматическую подгрузку комментариев - если у меня открыта страница с комментариями и кто-то другой добавляет новый, он у меня автомагически появляется (возможна задержка в 2-5 секунд). У айтема должны быть лайки (не более одного от одного пользователя на айтем).

- Сайт должен поддерживать два языка: русский и английский (пользователь выбирает и выбор сохраняется).

- Сайт должен поддерживать два оформления (темы): светлое и темное (пользователь выбирает и выбор сохраняется). 

Обязательно: Bootstrap (или любой другой CSS-фреймворк), поддержка разных разрешений (в том числе с телефона), ORM для доступа к данным (Hibernate, ActiveRecord, другое), движок для полнотекстового поиск (или средствами базы, или отдельный движок — НЕ ПОЛНОЕ СКАНИРОВАНИЕ селектами). А можно использовать вот библиотеку X? Да, можно. 

## Требования со звездочкой (лишь опционально, на 10/10, после реализации остальных требований):

- Вход через социальные сети.

- Добавить возможность полей в айтемах, которые являются "выбором из списка", с возможностью задания значений.

- Добавить возможность поддержки произвольного числа кастомных полей, а не по три одного из пяти видов).

- Добавить возможность экспорта коллекции в CSV-файл.

