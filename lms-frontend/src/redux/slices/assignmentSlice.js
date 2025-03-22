import { createSlice, createAsyncThunk } from '@reduxjs/toolkit';
import assignmentService from '../../services/assignmentService';

export const fetchAssignmentsByCourse = createAsyncThunk('assignments/fetchByCourse', async (courseId, thunkAPI) => {
  try {
    const response = await assignmentService.fetchAssignmentsByCourse(courseId);
    return response.data.data;
  } catch (err) {
    return thunkAPI.rejectWithValue(err.response.data.message);
  }
});

const assignmentSlice = createSlice({
  name: 'assignments',
  initialState: { assignments: [], error: null },
  reducers: {},
  extraReducers: (builder) => {
    builder
      .addCase(fetchAssignmentsByCourse.fulfilled, (state, action) => {
        state.assignments = action.payload;
        state.error = null;
      })
      .addCase(fetchAssignmentsByCourse.rejected, (state, action) => {
        state.error = action.payload;
      });
  }
});

export default assignmentSlice.reducer;
