$(document).ready(function(){
	$("a").click(function(){
		var url = $(this).attr("href");
		window.external.openUrl(url);
	});
});