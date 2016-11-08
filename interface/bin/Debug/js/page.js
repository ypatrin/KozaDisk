if(document.getElementsByClassName) { // есть есть родная фукнция, используем ее
	getElementsByClass = function(classList, node) {    
		return (node || document).getElementsByClassName(classList) // вызываем метод getElementsByClassName нужного узла.
		// если  указан node, то будет произведен поиск в нем, иначе во всем документе
	}

} else { // если родной функции нет, то будем обходить DOM
	getElementsByClass = function(classList, node) {			
		var node = node || document, // узел, в котором ищем
			list = node.getElementsByTagName('*'),  // выбираем все дочерние узлы
			length = list.length, // количество дочерних узлов
			classArray = classList.split(/\s+/), // разбиваем список классов
			classes = classArray.length, // длина списка классов 
			result = [], i,j
		for(i = 0; i < length; i++) { // перебираем все дочерние узлы
			for(j = 0; j < classes; j++)  { //перебираем все классы
				if(list[i].className.search('\\b' + classArray[j] + '\\b') != -1) { // если текущий узел имеет текущий класс
					result.push(list[i]) // запоминаем его
					break // прекращаем перебор классов
				}
			}
		}
	
		return result // возвращаем набор элементов
	}
}

function procCalendar()
{
	var dateElements = getElementsByClass('date');
	var calIds = [];
	
	for (var i = 0; i < dateElements.length; i++)
	{
       calIds.push(dateElements[i].id);
	}
	
	var calendar = new dhtmlXCalendarObject(calIds);
	
	dhtmlXCalendarObject.prototype.langData["ru"] = {
		dateformat: '%d.%m.%Y',
		monthesFNames: ["Январь","Февраль","Март","Апрель","Май","Июнь","Июль","Август","Сентябрь","Октябрь","Ноябрь","Декабрь"],
		monthesSNames: ["Янв","Фев","Мар","Апр","Май","Июн","Июл","Авг","Сен","Окт","Ноя","Дек"],
		daysFNames: ["Воскресенье","Понедельник","Вторник","Среда","Четверг","Пятница","Суббота"],
		daysSNames: ["Вс","Пн","Вт","Ср","Чт","Пт","Сб"],
		weekstart: 1,
		weekname: "н",
		today: "Сегодня",
		clear: "Очистить"
	};
	
	calendar.loadUserLanguage("ru");
	calendar.hideTime();
}