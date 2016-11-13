angular.module('MyApp')
.controller('DropdownlistController',function($scope,LocationService){

    $scope.CityId = null;
    $scope.NaighborhoodId = "All";
    $scope.CitiesList = null;
    $scope.NaibList = null;

  
    $scope.NaibTextShow = "Select Naighborhood";
    $scope.Result = "";

    LocationService.GetCities().then(function (d) {
        $scope.CitiesList = d.data;
    }, function (error) {
        alert('Error!');
    }
    );
    $scope.GetNaighborhood = function () {
        $scope.NaighborhoodId = null;
        $scope.NaibList = null;
        $scope.NaibTextShow = "Please wait..."
       

        LocationService.GetNaighborhood($scope.CityId).then(function (d) {
            $scope.NaibList = d.data;
            $scope.NaibTextShow = "Select Naighborhood";
           
        }, function (error) {
            alert('Error!');
        }
        );
    }
    $scope.GetPosts = function () {

        LocationService.GetPosts($scope.CityId).then(function (d) {
            
        })
    }
    //$scope.GetPosts = function () {
    //    $http.get('/Rent/Index?CityId=' + $scope.CityId). success(function (data, status) {
    //        $scope.data = data;
    //    }).error(function (data, status) {
    //    alert('error')})
    //}
    //$scope.GetPosts = function () {
    //    $http({
    //        method: 'Get',
    //        url: '/Rent/Index?CityId'+$scope.CityId
    //    })
     // $http.get('/Rent/Index?CityId?='+$scope.CityId)
    //}
    
        //$scope.ShowResult = function(){
        //    $scope.Result = $scope.CityId;
        //}
    })
.factory('LocationService', function ($http) {
    var fac = {};
    fac.GetCities = function () {
        return $http.get('/Rent/GetCities')
    }
    fac.GetNaighborhood = function (cityId) {
        return $http.get('/Rent/GetNaighborhood?cityId='+cityId)

    }

    fac.GetPosts = function (CityId) {
        return $http.get('/Rent/Index?CityId='+CityId)
    }
    return fac;
})