app.factory('memberService',
  function ($http, $routeParams) {
      return {
          getDataById: function () {
              //return promise from here
              return $http.get("http://localhost:40001/api/Members", {
                  params: { id: $routeParams.id }
              });
          }
      };
  });
