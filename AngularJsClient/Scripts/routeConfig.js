app.config(function($routeProvider, $locationProvider) {
    $routeProvider.caseInsensitiveMatch = true;
    $routeProvider
    .when("/",
    {
        templateUrl: "Temaplates/members.html",
        controller: "membersController",
        resolve : {
            memberList : function($http) {
                return $http.get("http://localhost:40001/api/Members")
                    .then(function (response) {
                        return response.data;
                    })
            }
        } 
    })
    .when("/members/create",
        {
            templateUrl: "Temaplates/create.html",
            controller: "memberCreateController"
        })
    .when("/members/edit/:id",
        {
            templateUrl: "Temaplates/edit.html",
            controller: "memberEditController"
        })
    .when("/members/delete/:id",
        {
            templateUrl: "Temaplates/delete.html",
            controller: "memberDeleteController"
        })
    .when("/members/details/:id",
        {
            templateUrl: "Temaplates/details.html",
            controller: "memberDetailsController"
        })
    .otherwise({
            redirectTo : "/"
        })
    $locationProvider.html5Mode(true);
})