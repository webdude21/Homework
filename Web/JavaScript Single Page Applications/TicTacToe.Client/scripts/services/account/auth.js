ticTacToeApp.factory('auth', function($http, $q, identity, authorization, UsersResource, baseUrl) {
    var logoutRoute = baseUrl + '/api/account/logout';
    var loginRoute = baseUrl + '/token';

    function logout() {
        var deferred = $q.defer();

        var headers = authorization.getAuthorizationHeader();
        $http.post(logoutRoute, {}, { headers: headers }).success(function() {
            identity.currentUser = undefined;
            deferred.resolve();
        });

        return deferred.promise;
    }

    function signup (user){
        var deferred = $q.defer();

        var user = new UsersResource.register(user);
        user.$save().then(function() {
            deferred.resolve();
        }, function(response) {
            deferred.reject(response);
        });

        return deferred.promise;
    }

    function login(user){
        var deferred = $q.defer();
        user['grant_type'] = 'password';
        $http.post(loginRoute, 'username=' + user.username + '&password=' + user.password + '&grant_type=' + user.grant_type,
            { headers: {'Content-Type': 'application/x-www-form-urlencoded'} }).success(function(response) {
            if (response["access_token"]) {
                identity.currentUser = response;
                deferred.resolve(true);
            }
            else {
                deferred.resolve(false);
            }
        });

        return deferred.promise;
    }

    function isAuthenticated() {
        if (identity.isAuthenticated()) {
            return true;
        }
        else {
            return $q.reject('not authorized');
        }
    }

    return {
        logout: logout,
        login: login,
        isAuthenticated: isAuthenticated,
        signup: signup
    }
});