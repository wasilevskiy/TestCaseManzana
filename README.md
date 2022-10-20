# Сервис инициации массовых операций и обременений.
Данный сервис предназначен для параллельной обработки потоков клиентов ФЛ/ИП из платформы УАСП (унифицированная аналитическая системная платформа) и ЦФТ 2.

# Структура МС
Микросервис состоит из 6 проектов:

| Название						| Значение																	  |
| ------------------------------|----------------------------------------------------------------------------:|
| CENTROS.Imo.Application       | входная точка проекта, которая содержит WebApi							  |
| CENTROS.Imo.Bl			    | бизнес слой проекта. Здесь лежат реализации	сервисов  + вся бизнес логика |
| CENTROS.Imo.DAL               | слой доступа данных. Общение с БД, реализация репозиториев                  |   
| CENTROS.Imo.Processes			| библиотека с описанными процессами в движке								  |
| CENTROS.Imo.Domain			| Модели (бизнес, интеграции). Абстракции (интерфейсы)						  |
| CENTROS.Imo.Pg				| Описание БД на PostgresSql в EF core										  |

<details>
<summary><h1>Строки конфига</h1></summary>

## Секция "ConnectionStrings"
| Название						| Назначение																  |
| ------------------------------|----------------------------------------------------------------------------:|
| mainDB				        | строка подключения к БД МС ИМО											  |

## Секция "Profile" - интеграция с профайлом
| Название						| Назначение																   |
| ------------------------------|-----------------------------------------------------------------------------:|
| FilePath				        | путь к файлу в shared folder системы Profile								   |
| FileName						| название файла с расширением системы Profile								   |
| ChunkLength					| количество строк в чанке при вставке в БД ФАСов из .csv файла системы Профайл|
  
</details>

# Логирование
1. Все exceptions записываются в LogError.
2. Все манипуляции на create/update/delete в БД записываются как LogInfo
3. Select в БД и простая информация записываются как LogTrace

<details>
<summary><h1>Gitflow</h1></summary> GitFlow
Есть 4 ветки: Master, Develop, Test, Release.

## Master
Ветка master предназначена для стабильной версии. Здесь лежит актуальная версия для пром среды.

## Develop
Ветка develop предназначена для dso стенда. Сюда сливаются все доработки из features для тестирования и отладки на dso. После чего features ветки сливаются в test.

## Test
Ветка test предназначена для стенда IFT. Сюда сливаются отлаженные на dso features ветки для последующего тестирования тестировщиками и аналитиками на ифт.

## Release
Ветка release предназначена для сборки релизов, путем ответливания от мастера и слива в release всех доработка из features, которые пойдут в пром. Далее ветка должна быть установлена на стенд предпрод для последующего тестирования 
тестировщиками и аналитиками. После удачной установки на пром - данная ветка сливается в master. Как стабильная версия.

## Bugfix
Ветка предназначена для исправления багов. Бранчуется от мастера и сливается в dso->test->release.

</details>

# Метрики приложения
Сбором метрик занимается Prometheus. Помимо системных метрик предоставленных из коробки в приложении будут реализованы кастомные метрики:

| Название										| Назначение																			|
| ----------------------------------------------|--------------------------------------------------------------------------------------:|
| active_db_connections							| количество активных подключений к БД													|
| <Фасы без обременений>						| количество пришедших ФАСов, у которых не существует в нашей БД документ обременения	|
| <Количество ФАСов из ПРОФАЙЛА>				| сколько ФАСов пришло в .csv документе от ПРОФАЙЛа										|
| <Количество необработанных ФАСов из ПРОФАЙЛа>	| сколько строк не обработалось из .csv документа от ПРОФАЙЛа							|
| <Количество ФАСов из УАСПА>					| сколько ФАСов пришло по кафке от УАСПА												|
| <Количество необработанных ФАСов из УАСПа>	| сколько ФАСов не обработалось из кафки от УАСПА										|
| <Кол-во отправленных ФАСов в МС Арестов>		| сколько ФАСов отправили в МС Арестов													|
| <Кол-во отправленных ФАСов в МС Взысканий>	| сколько ФАСов отправили в МС Взысканий												|
| <Кол-во отправленных ФАСов в МС Обременений>	| сколько ФАСов отправили в МС Обременений												|
| <Кол-во отправленных ФАСов в ЦЕНТРОС-1>		| сколько ФАСов отправили в ЦЕНТРОС-1													|
| <Кол-во запросов API>							| Кол-во запросов во все методы API, разбитые по методам								|

<details>
<summary>Трассировка приложения</summary>
# Трассировка приложения
to be continued
</details>

#Методы API
