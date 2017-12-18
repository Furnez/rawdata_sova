define(['knockout', 'dataservice'], (ko, dataservice) => {
    return function (params) {
        var posts = ko.observableArray([]);
        var comments = ko.observableArray([]);
         
        var getPost = (id) => {
            dataservice.getPost(id, data => {
                posts(data.posts);
                comments(data.comments);
            });
        };

        getPost(params.indexpage());

        return {
            posts
        };
    }
});
