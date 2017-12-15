define(['knockout', 'jquery', 'dataservice'], (ko, $, dataservice) => {
    return function (params) {
        var posts_search = ko.observableArray([]);
        var showPost = (id) => {console.log(id,params);params.showPost(id);}
        var getPosts = (search) => {
            console.log(search)
            dataservice.getResult(search, (data) => {
                posts_search(data);
            });
        };

        $('#button-search').click(() => {
            getPosts($('.form-control').val());
        });

        getPosts($('.form-control').val());

        return {
            posts_search,
            showPost
        };
    }
});
