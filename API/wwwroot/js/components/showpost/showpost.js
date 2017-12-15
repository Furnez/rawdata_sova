define(['knockout', 'dataservice'], (ko, dataservice) => {
    function Posts(params) {
        this.posts = ko.observableArray([]);
        this.title = ko.observable("KNOCKOUT");


        this.getPostss = () => {
          dataservice.getPost(19, (e) => {
            console.log(e.posts);
            this.posts(e.posts);
          });
        };

       this.getPostss();
    }

    return Posts;
});
