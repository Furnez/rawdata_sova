define(['knockout', 'jquery', 'dataservice'], (ko, $, dataservice) => {
    return function (params) {
        var posts_search = ko.observableArray([]);
        var showPost = (id) => {console.log(id,params);params.showPost(id);}
        var getPosts = (search) => {
        //need to call if button clicked again
                $('.toHideAfterBinding').fadeIn();
                console.log("salut");
                    $('.toShowAfterBinding').hide();
            dataservice.getResult(search, (data, err) => {
                if (err != "error") {
                    posts_search(data);
                    console.log(posts_search()[0].title);
                    console.log(posts_search()[1].title);
                    $('.toHideAfterBinding').fadeOut(1000);
                    $('.toShowAfterBinding').show(400);
                }else{
                    $('.toHideAfterBinding').fadeOut(1000);
                    $('.toShowAfterBinding').show(400);
                }
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
