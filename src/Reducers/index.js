import { CalendarBuilder } from '../CalendarBuilder';
import { cloneDeep } from "lodash";

export const initialState = {
    BookingDetails: [],
    CalendarData: {},
    FirstName: "",
    LastName: ""
};

export const Reducer = (state = initialState, action) => {

    let number;
    let targetYear;

    if (state.CalendarData.Weeks) {
        number = state.CalendarData.MonthNumber;
        targetYear = state.CalendarData.Year;
    }

    switch (action.type) {
        case 'INIT':
            return Object.assign({}, state, updateCalenderUI(action.data));
        case 'ADDMONTH':
            number++

            if (number === 13) {
                number = 1;
                targetYear = state.CalendarData.Year + 1;
            }

            return Object.assign({}, state, { CalendarData: mutateClonedCalenderState(state, number, targetYear) });

        case 'MINUSMONTH':
            number--

            if (number === 0) {
                number = 12;
                targetYear = state.CalendarData.Year - 1;
            }

            return Object.assign({}, state, { CalendarData: mutateClonedCalenderState(state, number, targetYear) });

        case 'OPENMODAL':
            return Object.assign({}, state, { CalendarData: mutateClonedModalState(state, action.dayNumber, 'Open') });
        case 'CLOSEMODAL':
            return Object.assign({}, state, { CalendarData: mutateClonedModalState(state, action.dayNumber) });
        case 'SAVENEWBOOKING':
            return Object.assign({}, state, updateCalenderUI(updateCalenderAfterNewBooking(state, action.updatedData)))
        default:
            return state;
    }
};

const updateCalenderUI = (data, targetMonth = getCurrentMonth(), targetYear = getCurrentYear()) => {
    let calendarBuilder = new CalendarBuilder();

    let calendarData = calendarBuilder.GetMonth(targetMonth, targetYear);

    calendarData.DaysOfTheWeek = ["Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday", "Sunday"]
    calendarData.Weeks = hydrateDayInstance(calendarData, data.BookingDetails, targetYear)

    return Object.assign(data, { CalendarData: calendarData })
}

const updateCalenderAfterNewBooking = (state, data) => {
    let clonedState = cloneDeep(state);
    return Object.assign({}, clonedState, { BookingDetails: data })
}

const mutateClonedCalenderState = (state, monthNumber, targetYear) => {
    let clonedState = cloneDeep(state);
    let result = updateCalenderUI(clonedState, monthNumber, targetYear);

    return result.CalendarData
}

const hydrateDayInstance = (month, bookingDetails, currentYear) => {

    let filteredMonth = month.Weeks.filter(x => x !== null)

    let todaysMonth = filteredMonth.map(week => ({
        Days: week.Days.map(d => ({
            number: d,
            highlight: (d === new Date().getDate()) && (month.MonthNumber === getCurrentMonth()),
            bookingDetails: hydrateBookingDetails(d, month, bookingDetails),
            date: `${d}/${month.MonthNumber}/${currentYear}`
        }))
    }))

    return todaysMonth
}

const hydrateBookingDetails = (dayNumber, month, bookingDetails) => {
    let result = bookingDetails.filter(b => (dateConverter(b.Date).getDate() === dayNumber) && (dateConverter(b.Date).getMonth() + 1 === month.MonthNumber))

    if (result.length > 0) {
        result.forEach((bk) => {
            let startTime = new Date(parseInt(bk.StartTime.substr(6)));
            let endTime = new Date(parseInt(bk.EndTime.substr(6)));
            bk.StartTime = `${startTime.getDate()}/${startTime.getMonth() + 1}/${startTime.getFullYear()}`
            bk.EndTime = `${endTime.getDate()}/${endTime.getMonth() + 1}/${endTime.getFullYear()}`
        })

        return result
    } else {
        return []
    }
}

const mutateClonedModalState = (state, dayNumber, modalState = null) => {
    let clonedState = cloneDeep(state);
    let result = setModal(clonedState, dayNumber, modalState)

    return result.CalendarData
}

const setModal = (data, number, modalAction = null) => {

    let newWeeksArray = data.CalendarData.Weeks.map(week => ({
        Days: week.Days.map(d => ({
            number: d.number,
            highlight: d.highlight,
            date: d.date,
            bookingDetails: updateModalState(d, number, modalAction),
            openNewModal: (d.number === number) && modalAction != null
        }))
    }))

    data.CalendarData.Weeks = [...newWeeksArray]

    return cloneDeep(data);

}

const updateModalState = (day, number, modalAction) => {

    if (modalAction === "Open" && day.bookingDetails.length > 0) {
        if (day.number === number) {
            day.bookingDetails[0].OpenModal = true
            return [day.bookingDetails[0]]
        }
        else {
            if (day.bookingDetails.length) {
                day.bookingDetails[0].OpenModal = false
            }
            return [day.bookingDetails[0]]
        }
    }
    else if (day.bookingDetails.length > 0) {
        if (day.number === number) {
            day.bookingDetails[0].OpenModal = false
            return [day.bookingDetails[0]]
        } else {
            return [day.bookingDetails[0]]
        }

    } else {
        return []
    }

}

const dateConverter = (date) => {
    return new Date(parseInt(date.substr(6)))
}

const getCurrentMonth = () => {
    return new Date().getMonth() + 1
}

const getCurrentYear = () => {
    return new Date().getFullYear()
}




