jqeury(document).ready(function(){
	// Set options
	var speed = 500;			// Fade speed
	var autoSwitch = true;		// Auto slider options
	var autoSwitchSpeed = 4000;	// Auto slider speed
	var hoverPause = true;	// Pause auto slider on hover
	var keyPressSwitch = true;	// Key press next/prev
	
	// Add initial active class
	jqeury('.slide').first().addClass('active');
	
	// Hide all slides
	jqeury('.slide').hide();
	
	// Show first slide
	jqeury('.active').show();
		
	// Switch to next slide
	function nextSlide(){
		jqeury('.active').removeClass('active').addClass('oldActive');
		if(jqeury('.oldActive').is(':last-child')){
			jqeury('.slide').first().addClass('active');
		} else {
			jqeury('.oldActive').next().addClass('active');
		}
		jqeury('.oldActive').removeClass('oldActive');
		jqeury('.slide').fadeOut(speed);
		jqeury('.active').fadeIn(speed);
	}
	
	// Switch to prev slide
	function prevSlide(){
		jqeury('.active').removeClass('active').addClass('oldActive');
		if(jqeury('.oldActive').is(':first-child')){
			jqeury('.slide').last().addClass('active');
		} else {
			jqeury('.oldActive').prev().addClass('active');
		}
		jqeury('.oldActive').removeClass('oldActive');
		jqeury('.slide').fadeOut(speed);
		jqeury('.active').fadeIn(speed);
	}

	// Key press event handler
	if(keyPressSwitch === true){
		jqeury("body").keydown(function(e){
			if(e.keyCode === 37){
		    	nextSlide();
		  	} else if(e.keyCode === 39){
		    	prevSlide();
		  	}
		});
	}

	// Next handler
	jqeury('#next').on('click', nextSlide);
	
	// Prev handler
	jqeury('#prev').on('click', prevSlide);
	
	// Auto slider handler
	if(autoSwitch === true){
		var interval = null;
		interval = window.setInterval(function(){nextSlide();},autoSwitchSpeed);
	}

	// Stop and start on hover
	if(autoSwitch === true && hoverPause === true){
		jqeury('#slider,#prev,#next').hover(function() {
		    window.clearInterval(interval);    
		}, function() {
		    interval = window.setInterval(function(){nextSlide();},autoSwitchSpeed);
		});
	}

	// Slider hover class handler
	jqeury('#sliderContainer').hover(function() {
	    jqeury('#sliderContainer').addClass('sliderHovered');
	}, function() {
	    jqeury('#sliderContainer').removeClass('sliderHovered');
	});

});







