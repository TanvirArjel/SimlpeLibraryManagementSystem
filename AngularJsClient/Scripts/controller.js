app.controller("membersController", function ($scope, memberList) {
    $scope.pageHeader = "Member Page";
        $scope.members = memberList;
    })
   .controller("memberCreateController", function ($scope, $http, $location) {
       $scope.pageHeader = "Create/Add Member";
       $scope.member = {};
       $scope.createMember = function (member) {
           $http.post('http://localhost:40001/api/Members', member)
               .success(function () {
                   alert("Member Created Successfully");
                   $location.path('/');

               });
       }

   })
 .controller("memberDetailsController", function ($scope, $http, $routeParams, $location, memberService) {
     $scope.pageHeader = "Member Details";
     memberService.getDataById().then(function (response) {
         $scope.member = response.data;
     }, function (error) {
         console.log("Error occured ", error);
     });

     //First I wrote the following code in every controller where it needed. but it produced lots of code duplication and hence move this 
     //code into a angularjs service named "memberService"(which is in factory.js file) and then inject the service into each controller 
     //it needded and called the service method name "getDataById()".

    // $http({
    //     method: "GET",
     //     url: "http://localhost:40001/api/Members",
    //     params: { id: $routeParams.id }
    // })
    //.then(function (response) {
    //    console.log(response);
    //    $scope.member = response.data;
    //})

 })
.controller("memberEditController", function ($scope, $http, $routeParams, $location, memberService) {
    $scope.pageHeader = "Edit Member";
    $scope.member = {};

    memberService.getDataById().then(function (response) {
        $scope.member = response.data;
    }, function (error) {
        console.log("Error occured ", error);
    });

    //First I wrote the following code in every controller where it needed. but it produced lots of code duplication and hence move this 
    //code into a angularjs service named "memberService"(which is in factory.js file) and then inject the service into each controller 
    //it needded and called the service method name "getDataById()".

    //    $http({
    //        method: "GET",
    //        url: "http://localhost:40001/api/Members",
    //        params: { id: $routeParams.id }
    //    })
    //    .then(function (response) {
    //        $scope.member = response.data;
    //    })
    $scope.updateMember = function (member) {
        $http({
            method: "PUT",
            url: "http://localhost:40001/api/Members",
            params: { id: $routeParams.id },
            data: member
        })
        .success(function () {
            alert("Member Updated Successfully");
            $location.path('/');
        });
    }

})

.controller("memberDeleteController", function ($scope, memberService, $http, $routeParams, $location) {
    $scope.message = "Delete Member!";

    memberService.getDataById().then(function (response) {
        $scope.member = response.data;
    }, function (error) {
        console.log("Error occured ", error);
    });

    //First I wrote the following code in every controller where it needed. but it produced lots of code duplication and hence move this 
    //code into a angularjs service named "memberService"(which is in factory.js file) and then inject the service into each controller 
    //it needded and called the service method name "getDataById()".

    //    $http({
    //        method: "GET",
    //        url: "http://localhost:40001/api/Members",
    //        params: { id: $routeParams.id }
    //    })
    //    .then(function (response) {
    //        $scope.member = response.data;
    //    })
    $scope.deleteMember = function () {
        $http({
            method: "Delete",
            url: "http://localhost:40001/api/Members",
            params: { id: $routeParams.id },
        })
        .success(function () {
            alert("Member Deleted Successfully");
            $location.path('/');
        });
    }

})