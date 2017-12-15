require.config({
    baseUrl: "js",
    paths: {
        jquery: "../lib/jquery/dist/jquery.min",
        knockout: "../lib/knockout/dist/knockout",
        text: "../lib/text/text",
        dataservice: 'services/dataservice',
    }
});

require(['knockout'], (ko) => {

    ko.components.register('post-list',
        {
            viewModel: { require: 'components/postlist/postlist' },
            template: { require: 'text!components/postlist/postlist_view.html' }
        });

    ko.components.register('show-post',
        {
            viewModel: { require: 'components/showpost/showpost' },
            template: { require: 'text!components/showpost/showpost_view.html' }
        });

     ko.components.register('search-result',
        {
            viewModel: { require: 'components/searchresult/searchresult' },
            template: { require: 'text!components/searchresult/searchresult_view.html' }
        });
});

require(['knockout'], (ko) => {
    var view = {
        currentView: ko.observable('post-list'),
        postSearch: function () {
            this.currentView('search-result');
        },
        showPost: function () {
            console.log("ENTER VIEW FUNC");
            this.currentView('show-post');
        },
    };

    ko.applyBindings(view);
});