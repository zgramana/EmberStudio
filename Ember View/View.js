// Replace `MyApp` with your App's name.
// Replace `div` with your View's tag name.
// Replace `my-div` with your element id.
// Replace `container` with your custom class name.
MyApp.$fileinputname$ = Ember.View.extend({
    tagName: 'div',
    elementId: 'my-div',
    classNames: ['container'],
	click: function (e) {
		e.preventDefault(); // Prevent event bubbling.
		// Do something.
	}
});