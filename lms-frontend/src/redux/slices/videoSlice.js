import { createSlice } from '@reduxjs/toolkit';

const videoSlice = createSlice({
  name: 'videos',
  initialState: { videos: [], error: null },
  reducers: {
    addVideo: (state, action) => {
      state.videos.push(action.payload);
    }
  }
});

export const { addVideo } = videoSlice.actions;
export default videoSlice.reducer;
