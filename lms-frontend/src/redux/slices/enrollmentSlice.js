import { createSlice } from '@reduxjs/toolkit';

const enrollmentSlice = createSlice({
  name: 'enrollment',
  initialState: { enrolled: false, error: null },
  reducers: {
    setEnrolled: (state, action) => {
      state.enrolled = action.payload;
    }
  }
});

export const { setEnrolled } = enrollmentSlice.actions;
export default enrollmentSlice.reducer;
