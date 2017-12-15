require.config({
    baseUrl: "js",
    paths: {
        jquery: "../lib/jquery/dist/jquery.min",
        bootstrap: "../lib/bootstrap/dist/js/bootstrap.min",
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
        currentView: ko.observable('search-result')/*,
        changeView: function () {
            this.currentView('search-result');
        }*/
    };

    ko.applyBindings(view);
});