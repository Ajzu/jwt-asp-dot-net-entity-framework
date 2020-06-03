using AutoMapper;
using DTOModel;
using EnityModel;
using Repositorie.Repositories;
using Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Service
{
    public class ChapterService : IChapterService
    {

        private readonly ChapterRepository _chapterRepository;
        private readonly SubjectChapterService _subjectChapterService;

        public ChapterService()
        {
            _chapterRepository = new ChapterRepository();
            _subjectChapterService = new SubjectChapterService();
        }

        public async Task<ApiResponse<Chapter>> GetChapterById(Guid id)
        {
            var response = new ApiResponse<Chapter>();
            Chapter chapter = await _chapterRepository.GetByGuidAsync(id);
            if (chapter == null)
            {
                response.Success = false;
                return response;
            }
            response.Success = true;
            response.Data = chapter;
            return response;
        }

        public async Task<ApiResponse<IEnumerable<Chapter>>> GetAllChapters()
        {
            var response = new ApiResponse<IEnumerable<Chapter>>();
            IEnumerable<Chapter> chapter = await _chapterRepository.GetAllAsyn();
            if (chapter == null)
            {
                response.Success = false;
                return response;
            }
            response.Success = true;
            response.Data = chapter;
            return response;
        }

        public async Task<ApiResponse<IEnumerable<Chapter>>> GetChaptersBySubjectId(Guid id)
        {
            var response = new ApiResponse<IEnumerable<Chapter>>();
            List<Chapter> chapters = new List<Chapter>();
            
            ApiResponse<IEnumerable<SubjectChapter>> subjectsChapter = new ApiResponse<IEnumerable<SubjectChapter>>();
            subjectsChapter = await _subjectChapterService.GetChaptersBySubjectId(id);
            foreach(SubjectChapter sc in subjectsChapter.Data)
            {
                Chapter chapter = await _chapterRepository.GetByGuidAsync(sc.ChapterId);
                if (chapter != null)
                {
                    chapters.Add(chapter);
                }
            }

            if (chapters == null)
            {
                response.Success = false;
                return response;
            }
            response.Success = true;
            response.Data = chapters;
            return response;
        }

        public async Task<ApiResponse<Chapter>> CreateChapter(ChapterDto chapterDto)
        {
            var response = new ApiResponse<Chapter>();
            try
            {
                //check chapter Exists
                var isExistChapter = await _chapterRepository.CountAsync(i => i.Name == chapterDto.Name);

                if (isExistChapter != 0)
                {
                    response.Success = false;
                    response.Errors.Add("Chapter Already Exists");
                    return response;
                }

                var id = Guid.NewGuid();

                //create new chapter
                var chapter = Mapper.Map<Chapter>(chapterDto);
                chapter.Id = id;
                chapter.CreatedDate = DateTime.Now;
                chapter.IsActive = true;
                await _chapterRepository.AddAsyn(chapter);
                response.Success = true;
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Errors.Add(ex.Message);
            }
            return response;
        }
    }
}
