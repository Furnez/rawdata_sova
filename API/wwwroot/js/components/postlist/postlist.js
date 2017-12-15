define(['knockout', 'dataservice'], (ko, dataservice) => {
    return function (params) {
        var posts = ko.observableArray([]);
        var showPost = (id) => {console.log(id,params);params.showPost(id);}
        var getPosts = function () {
            dataservice.getPosts(data => {
                posts(data);
            });
        };

        getPosts();

        return {
            posts,
             showPost
        };
    }
});