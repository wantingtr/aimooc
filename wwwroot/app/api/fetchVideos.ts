export default {
    getVideoList: () => {
        return fetch('../../api/rest/getcoursetypelist', {
            method: 'get'
        }).then(function (response) {
            return response.json();
        }).then(function (response) {
            return response;
        });
    },

    getVideo: (courseID: any) => {
        return fetch('../../api/rest/getvideo?courseID='+courseID, {
            method: 'get'
        }).then(function (response) {
            return response.json();
        }).then(function (response) {
            return response;
        });
    }

}