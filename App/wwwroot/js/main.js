require.config({

    baseUrl: "js",

    paths: {
        jquery: '../lib/jQuery/dist/jquery.min',
        knockout: '../lib/knockout/dist/knockout',
        text: '../lib/text/text',
        bootstrap: '../lib/bootstrap/js/bootstrap.min'
    }
});

// Example of creating new components
/*
require(['knockout'], function (ko) {

    ko.components.register("mylist", {
        viewModel: {
            require: "components/mylist/mylist"
        },
        template: {
            require: "text!components/mylist/mylist_view.html"
        }
    });

    ko.components.register("my-element", {
        viewModel: {
            require: "components/element/element"
        },
        template: {
            require: "text!components/element/element_view.html"
        }
    });
});
*/