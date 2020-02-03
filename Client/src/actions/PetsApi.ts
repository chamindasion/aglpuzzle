import Axios from 'axios';

declare var petApiUrl: any;

export class PetsApi {

  public static GetPetSummary = (petType) => {                 
    return  Axios(petApiUrl.concat('?petType=', petType), {
      method: 'GET',
      headers: {
        'Access-Control-Allow-Origin': '*',
        'Content-Type': 'application/json',
      },
    }).then(response => {
      console.log('All posts: ', response.data)
      var responseData = response.data;
      return responseData;
    })                           
  }
}

