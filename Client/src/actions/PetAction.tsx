import AppDispatcher from '../dispatcher/AppDispatcher';
import ActionConstants from '../constants/ActionConstants';
import {PetsApi} from './PetsApi'
import {PetType} from '../models/petType'

class PetAction {
    public getInitialPets(){
        AppDispatcher.dispatch({
            actionType: ActionConstants.PET_LOAD,
            initialPets: PetsApi.GetPetSummary(PetType.Cat)
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