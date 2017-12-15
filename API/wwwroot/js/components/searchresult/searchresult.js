define(['knockout', 'dataservice'], (ko, dataservice) => {
    function Search(params) {
        this.posts = ko.observableArray([]);
        this.title = ko.observable("KNOCKOUT");


        this.getPostss = () => {
          dataservice.getResult("hard-coding the number in", (e) => {
            console.log(e);
            this.posts(e);
          });
        };

       this.getPostss();
    }

    return Search;
});
