/*
$(document).ready(function() {
    $('a.click').click(function(){
		$('div.repos').toggleClass('highGround lowGround');
		$('div#exchangeZone').toggleClass('highGround lowGround');
		alert("Repos : "+$('div.repos').attr('class')+"\nExchange : "+$('div#exchangeZone').attr('class'));
	});
    
})
*/
$(window).load(function() {
    $('.highGround, .lowGround').click(function(){
		$('div.repos').toggleClass('highGround lowGround');
		$('div#exchangeZone').toggleClass('highGround lowGround');
		//alert("Repos : "+$('div.repos').attr('class')+"\nExchange : "+$('div#exchangeZone').attr('class'));
	});
    
})