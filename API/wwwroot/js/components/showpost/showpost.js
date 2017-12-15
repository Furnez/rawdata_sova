define(['knockout', 'dataservice'], (ko, dataservice) => {
    return function (params) {
        var post = ko.observableArray([]);
         
        var getPost = (id) => {
            dataservice.getPost(id, data => {
                console.log(data);
                post(data);
            });
        };

        console.log('PARAMS POST => ', params.indexpage());
        getPost(params.indexpage());

        return {
            post
        };
    }
});
