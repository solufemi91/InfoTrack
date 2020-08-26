//import { Reducer } from '../Reducers';
//import { render } from 'react-dom'
//import { createStore, compose } from 'redux';
//import CalendarContainer from '../Containers/CalendarContainer';
//import { Provider } from 'react-redux';


//const enhancers = compose(
//    window.__REDUX_DEVTOOLS_EXTENSION__ && window.__REDUX_DEVTOOLS_EXTENSION__()
//);

//const store = createStore(
//    Reducer, enhancers
//);

//const domContainer = document.getElementById('calendarContainer');
//const data = domContainer.getAttribute('data-react-model');
//const obj = JSON.parse(data);

//store.dispatch({ type: 'INIT', data: obj });

//render(
//    <Provider store={store}>
//        <CalendarContainer />,
//    </Provider>,
//    domContainer); 