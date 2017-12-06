require.config({

    baseUrl: "js",

    paths: {
        jquery: '../lib/jQuery/dist/jquery.min',
        knockout: '../lib/knockout/dist/knockout',
        text: '../lib/text/text',
        bootstrap: '../lib/bootstrap/js/bootstrap.min',
        home: 'services/home'
    }
});

require(['knockout', 'home'], function (ko, home) {
    var vm = (function () {
        var switchComponent = function () {
            home.getPosts();
        }

        return {
            switchComponent
        }
    })();

    ko.applyBindings(vm);
});