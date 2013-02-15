// Replace `MyApp` with your App's name.
MyApp.$fileinputname$ = Ember.Object.extend({
});

// Provide a hook for Route `model` lookup for dynamic routes.
MyApp.$fileinputname$.reopenClass({
	find: function(id) {
		return null;
	}
});
