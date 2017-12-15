define(['knockout', 'dataservice'], (ko, dataservice) => {
    function Search(params) {
        this.posts = ko.observableArray([]);
        this.title = ko.observable("KNOCKOUT");

        console.log(jQuery(searchinput).change());

        this.getPostss = (search) => {
        console.log(search)
          dataservice.getResult(search, (e) => {
            console.log(e);
            this.posts(e);
          });
        };
        $('#searchinput').change((e) => {console.log(e); this.getPostss(e.target.value)});
    }

    return Search;
});
