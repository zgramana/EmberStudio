Ember.ENV.DEBUG = false;
Ember.ENV.VERBOSE = false;

// Support for <= IE9 when debug window isn't open.
window.console = window.console || { log: Ember.K };

window.$safeprojectname$ = Ember.Application.create();

// Debug support.
if (Ember.ENV.DEBUG === true) {
    Ember.ENV.RAISE_ON_DEPRECATION = true;
    if (Ember.ENV.VERBOSE) {
        Ember.LOG_BINDINGS = true;
        Proto.LOG_TRANSITIONS = true;
    }
    Ember.Logger = {
            log: console.log,
            warn: console.warn || console.log,
            error: console.error || console.log,
            info: console.info || console.log,
            debug: console.debug || console.log
    };
} else {
    Ember.Logger = { log: Ember.K, warn: Ember.K, error: Ember.K, info: Ember.K, debug: Ember.K };
}