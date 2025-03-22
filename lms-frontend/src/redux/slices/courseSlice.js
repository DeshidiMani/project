import { createSlice, createAsyncThunk } from '@reduxjs/toolkit';
import courseService from '../../services/courseService';

export const fetchAllCourses = createAsyncThunk('courses/fetchAll', async (_, thunkAPI) => {
  try {
    const response = await courseService.fetchAllCourses();
    return response.data.data;
  } catch (err) {
    return thunkAPI.rejectWithValue(err.response.data.message);
  }
});

export const createCourse = createAsyncThunk('courses/create', async (courseData, thunkAPI) => {
  try {
    const response = await courseService.createCourse(courseData);
    return response.data.data;
  } catch (err) {
    return thunkAPI.rejectWithValue(err.response.data.message);
  }
});

const courseSlice = createSlice({
  name: 'courses',
  initialState: { courses: [], error: null },
  reducers: {},
  extraReducers: (builder) => {
    builder
      .addCase(fetchAllCourses.fulfilled, (state, action) => {
        state.courses = action.payload;
        state.error = null;
      })
      .addCase(fetchAllCourses.rejected, (state, action) => {
        state.error = action.payload;
      })
      .addCase(createCourse.fulfilled, (state, action) => {
        state.courses.push(action.payload);
      })
      .addCase(createCourse.rejected, (state, action) => {
        state.error = action.payload;
      });
  }
});

export default courseSlice.reducer;
