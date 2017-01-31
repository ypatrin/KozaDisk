$(document).ready(function(){
    $( "input" ).focus(function() {
        $(this).css( {
            "border-color": "#1abc9c",
            "background-color": "#fff"
        } );
    });
    $( "input" ).focusout(function() {
        $(this).css( {
        	"border-color": "#444444",
            "background-color": "#f7f7f7"
		} );

    });
    $( "input[type=text]" ).hover(function() {
        $(this).css( {
            "border-color": "#1abc9c",
            "background-color": "#fff"
        } );
    });
    $( "input[type=text]" ).mouseout(function() {
        $(this).css( {
            "border-color": "#444444",
            "background-color": "#f7f7f7"
        } );
    });
	$(".comment").hover(function(){
		var comment = $(this).attr("comment");
		window.external.showComment(comment);
	});
	
	var upFormulaTimeout = setTimeout(updateFormula, 1000);
	
	function updateFormula()
	{		
		$("input[text_type=formula]").each(function(){
		var formula = $(this);
		
		if (formula)
		{
			var formulaVal = formula.attr("formula");
			
			if (formulaVal && formulaVal != '')
			{
				var formulaResult = 0;
				
				//plus
				var formulaPlusParts = formulaVal.split("+");
				
				if (formulaPlusParts.length > 1)
				{
					$.each(formulaPlusParts, function(index, val){
						var partValue = $("#"+val).val();
						
						//if integer
						if (partValue == parseInt(partValue)) {
							formulaResult += parseInt(partValue);
						} else if (partValue == parseFloat(partValue)) {
							formulaResult += parseFloat(partValue);
						}
					}); 
				}

				//minus
				var formulaMinusParts = formulaVal.split("-");
				
				if (formulaMinusParts.length > 1)
				{
					$.each(formulaMinusParts, function(index, val){
						var partValue = $("#"+val).val();
						
						//if integer
						if (partValue == parseInt(partValue)) {
							formulaResult -= parseInt(partValue);
						}
						if (partValue == parseFloat(partValue)) {
							formulaResult -= parseFloat(partValue);
						}
					}); 
				}
			}
		}
		
		formula.val(formulaResult);
		});
		pFormulaTimeout = setTimeout(updateFormula, 1000);
	}
});

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
		monthesFNames: ["Січень","Лютий","Березень","Квітень","Травень","Червень","Липень","Сервень","Вересень","Жовтень","Листопад","Грудень"],
		monthesSNames: ["Січ","Лют","Бер","Квіт","Трав","Чер","Лип","Сер","Вер","Жов","Лис","Гру"],
		daysFNames: ["Неділя","Понеділок","Вівторок","Середа","Четвер","П'ятница","Субота"],
		daysSNames: ["Нд","Пн","Вт","Ср","Чт","Пт","Сб"],
		weekstart: 1,
		weekname: "н",
		today: "Сьгодні",
		clear: "Очистити"
	};
	
	calendar.loadUserLanguage("ru");
	calendar.hideTime();
}