window.onload = function () {

	var formHandler = document.forms.loginForm;
	var thankyoudiv = document.getElementById('userName').value;
	var chceker[] = document.getElementById("userId").value;
	formHandler.onsubmit = processForm;

	function processForm() {
		return false;
	}
}