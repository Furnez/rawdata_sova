define(['knockout', 'dataservice'], (ko, dataservice) => {
    return function (params) {
        var posts = ko.observableArray([]);

        var getPosts = function () {
            dataservice.getPosts(data => {
                posts(data);
            });
        };

        getPosts();

        return {
            posts,
        };
    }
});