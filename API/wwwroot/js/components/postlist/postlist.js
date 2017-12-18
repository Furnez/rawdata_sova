define(['knockout', 'tagcloud', 'dataservice'], (ko, tagc, dataservice) => {
    return function (params) {
        var posts = ko.observableArray([]);
        var showPost = (id) => {console.log(id,params);params.showPost(id);};
       /* var cloudShow = () => {
        console.log("salut");
        console.log($('#myCanvas'))
   if( ! $('#myCanvas').tagcanvas({
     textColour : '#ffffff',
     textHeight : 50,
     outlineThickness : 1,
     maxSpeed : 0.08,
     depth : 0.8
   })) {
     // TagCanvas failed to load
     $('#myCanvasContainer').hide();
   }
        };
        setTimeout(cloudShow,10000); // need to wait jquery loading*/

        var cloudShow = () => {
            var options;
            var entries = [];

            for (var i = 0; i < 10; i++) {
            console.log(posts()[i].id);
                options = {label: posts()[i].title, url: '#', target: '_top',id:posts()[i].id};
                entries.push(options);
            }
            console.log();
             var settings = {

                entries: entries,
                width: $('#tag-cloud')[0].clientWidth,
                height: 500,
                radius: '65%',
                radiusMin: 75,
                bgDraw: true,
                bgColor: '#111',
                opacityOver: 1.00,
                opacityOut: 0.05,
                opacitySpeed: 6,
                fov: 800,
                speed: 0.3,
                fontFamily: 'Oswald, Arial, sans-serif',
                fontSize: '15',
                fontColor: '#fff',
                fontWeight: 'normal',//bold
                fontStyle: 'normal',//italic 
                fontStretch: 'normal',//wider, narrower, ultra-condensed, extra-condensed, condensed, semi-condensed, semi-expanded, expanded, extra-expanded, ultra-expanded
                fontToUpperCase: true

            };

            $('#tag-cloud').svg3DTagCloud(settings);
        };


        var getPosts = function () {
            dataservice.getPosts(data => {
                posts(data);
                setTimeout(cloudShow,200);
            });

        };

        getPosts();

        return {
            posts,
             showPost,
             cloudShow
        };
    }
});