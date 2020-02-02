import AppDispatcher from '../dispatcher/AppDispatcher';
import ActionConstants from '../constants/ActionConstants';
import PetsApi from '../actions/PetsApi'

class PetAction {
    public getInitialPets(){
        AppDispatcher.dispatch({
            actionType: ActionConstants.PET_LOAD,
            initialPets: PetsApi.getPetSummary()
        })
    };
    public createPet(petText) {
        AppDispatcher.dispatch({
            actionType: ActionConstants.PET_CREATE,
            text: petText
        });
    };   
}
export default PetAction;