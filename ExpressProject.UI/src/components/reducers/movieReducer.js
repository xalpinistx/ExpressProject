const movie = (state, action) => {
    switch(action.type) {
        case "ADD_MOVIE": {
            return {
                //movie data to return
            }
        }
        default:
            return state;
    }
}

export default movie;