using DTOModel;
using EnityModel;
using Repositorie.Repositories;
using Service.Interface;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Utilities;


namespace Service.Service
{

    public class SubjectChapterService : ISubjectChapterService
    {

        private readonly SubjectChapterRepository _subjectChapterRepository;

        public SubjectChapterService()
        {
            _subjectChapterRepository = new SubjectChapterRepository();
        }

        public async Task<ApiResponse<IEnumerable<SubjectChapter>>> GetChaptersBySubjectId(Guid id)
        {
            var response = new ApiResponse<IEnumerable<SubjectChapter>>();
            IEnumerable<SubjectChapter> subjectchapters = await _subjectChapterRepository.FindAllAsync(x => x.SubjectId == id);
            if (subjectchapters == null)
            {
                response.Success = false;
                return response;
            }
            response.Success = true;
            response.Data = subjectchapters;
            return response;
        }

        public async Task<ApiResponse<SubjectChapter>> GetBySubjectChapterId(Guid id)
        {
            var response = new ApiResponse<SubjectChapter>();
            SubjectChapter subjectChapter = await _subjectChapterRepository.GetByGuidAsync(id);
            if (subjectChapter == null)
            {
                response.Success = false;
                return response;
            }
            response.Success = true;
            response.Data = subjectChapter;
            return response;
        }

        public async Task<ApiResponse<IEnumerable<SubjectChapter>>> GetAllSubjectChapters()
        {
            var response = new ApiResponse<IEnumerable<SubjectChapter>>();
            IEnumerable<SubjectChapter> subjectChapter = await _subjectChapterRepository.GetAllAsyn();
            if (subjectChapter == null)
            {
                response.Success = false;
                return response;
            }
            response.Success = true;
            response.Data = subjectChapter;
            return response;
        }

        public async Task<ApiResponse<SubjectChapter>> CreateSubjectChapter(SubjectChapterDto subjectChapterDto)
        {
            var response = new ApiResponse<SubjectChapter>();
            try
            {
                //check subjectchapter Exists
                var isExistSubjectChapter = await _subjectChapterRepository.CountAsync(i => i.SubjectId == subjectChapterDto.SubjectId && i.ChapterId == subjectChapterDto.ChapterId);

                if (isExistSubjectChapter != 0)
                {
                    response.Success = false;
                    response.Errors.Add("SubjectChapter Already Exists");
                    return response;
                }

                var id = Guid.NewGuid();
                var subjectChapter = Mapper.Map<SubjectChapter>(subjectChapterDto);
                subjectChapter.Id = id;
                subjectChapter.CreatedDate = DateTime.Now;
                subjectChapter.IsActive = true;
                await _subjectChapterRepository.AddAsyn(subjectChapter);
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