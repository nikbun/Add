$("form#form1 input.capital-letter").keyup(function (eventObject)
{
    var s = this.value;
    if (s != "")
    {
        s.substr(1, s.length);
        s = s[0].toUpperCase() + s.substr(1, s.length);
        this.value = s;
    }
})