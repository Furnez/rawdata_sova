define(['jquery'], function ($) {

    var getPosts = () => {
        $.ajax({
                // The URL for the request
                url: "http://localhost:63838/api/posts",
                type: "GET",
                dataType: "json",
            })
            .done(function (res) {
                console.log(res)
            }).fail(function (xhr, status, errorThrown) {
                alert("Sorry, there was a problem!");
                console.log("Error: " + errorThrown);
                console.log("Status: " + status);
                console.dir(xhr);
            })
            // Code to run regardless of success or failure;
            .always(function (xhr, status) {
                alert("The request is complete!");
            });
    };

    return {
        getPosts
    };
});