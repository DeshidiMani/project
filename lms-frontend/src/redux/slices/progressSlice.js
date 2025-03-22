import { createSlice, createAsyncThunk } from '@reduxjs/toolkit';
import progressService from '../../services/progressService';

export const fetchProgress = createAsyncThunk('progress/fetch', async ({ userId, courseId }, thunkAPI) => {
  try {
    const response = await progressService.fetchProgress(userId, courseId);
    return response.data.data;
  } catch (err) {
    return thunkAPI.rejectWithValue(err.response.data.message);
  }
});

const progressSlice = createSlice({
  name: 'progress',
  initialState: { progress: null, error: null },
  reducers: {},
  extraReducers: (builder) => {
    builder
      .addCase(fetchProgress.fulfilled, (state, action) => {
        state.progress = action.payload;
      })
      .addCase(fetchProgress.rejected, (state, action) => {
        state.error = action.payload;
      });
  }
});

export default progressSlice.reducer;
