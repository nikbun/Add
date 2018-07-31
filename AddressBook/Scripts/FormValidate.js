// Получаем все формы на странице
var forms = document.getElementsByTagName('form');

// К каждой форме прикрепляем слушатель
for (var i = 0; i < forms.length; i++)
{
	forms[i].addEventListener('submit', validator());
}

// Список правил проверок
var rules =
	{
		// Проверка на заполненность поля
		required: function (el)
		{
			if (el.value != '')
			{
				return true;
			}
		return false;
		},
		// Проверка на емайл
		email: function (el) {
			var reg = /^\w{1,}@\w{1,}\w{2,}$/;
			return reg.test(el.value);
		}
	}

// Вывести ошибку в консоль
function showErrors(arr)
{
	console.log(arr);
}

// Проверка полей
function validator(e)
{
	e.preventDefault();
	// Массив ошибок
	var errors = [];
	// Элементы формы
	var inputs = this.elements;

	// Обрабатываем каждый элемент формы
	for (var i = 0; i < inputs.length; i++)
	{
		// Проверка на кнопку
		if (inputs[i].tagName != 'BUTTON')
		{
			// Получаем из параметка data-rule строку правил проверки
			var rulesList = inputs[i].dataset.rule;
			// Перезаписываем строку в массив правил(правила разделены пробелом)
			rulesList = rulesList.split(' ');

			// Применяем все полученные правила для элемента
			for (var j = 0; j < rulesList.length; j++)
			{
				// проверка на наличие соответствующего правила
				if (rulesList[j] in rules)
				{
					// Если не проверка не прошло добавляем ошибку в массив ошибок
					if (!rules[rulesList[j]](inputs[i]))
					{
						errors.push(
							{
							name: inputs[i].name,
							error: rulesList[j]
						});
					}
				}
			}
		}
	}

	// Выводит список ошибок в консоль
	if (errors.length > 0)
	{
		e.preventDefault();
		showErrors(errors);
	}
}