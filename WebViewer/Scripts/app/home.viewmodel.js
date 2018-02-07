function HomeViewModel(app, dataModel) {
    var self = this;

    self.imageUrl = ko.observable("");

    Sammy(function () {
        this.get('#home',
            function () {
                // Make a call to the protected Web API by passing in a Bearer Authorization Header
                $.ajax({
                    method: 'get',
                    url: app.dataModel.userInfoUrl,
                    contentType: "application/json; charset=utf-8",
                    headers: {
                        'Authorization': 'Bearer ' + app.dataModel.getAccessToken()
                    },
                    success: function (data) {
                        self.imageUrl(data.imageUrl);
                    }
                });
            });
        this.get('#GetNewImage',
            function () {
                // Make a call to the protected Web API by passing in a Bearer Authorization Header
                $.ajax({
                    method: 'put',
                    url: app.dataModel.userInfoUrl,
                    contentType: "application/json; charset=utf-8",
                    headers: {
                        'Authorization': 'Bearer ' + app.dataModel.getAccessToken()
                    },
                    success: function (data) {
                        self.imageUrl(data.imageUrl);
                        this.redirect('#');
                    }
                });
            });
        this.get('/', function () { this.app.runRoute('get', '#home'); });
        this.get('#Reload', function() {
            this.redirect('#');
        });
        
    });
    return self;
}

app.addViewModel({
    name: "Home",
    bindingMemberName: "home",
    factory: HomeViewModel
});
