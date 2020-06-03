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
    public class SubjectService : ISubjectService
    {

        private readonly SubjectRepository _subjectRepository;
        private readonly CourseSubjectService _courseSubjectServices;

        public SubjectService()
        {
            _subjectRepository = new SubjectRepository();
            _courseSubjectServices = new CourseSubjectService();
        }

        public async Task<ApiResponse<Subject>> GetSubjectById(Guid id)
        {
            var response = new ApiResponse<Subject>();
            //Subject subject2 = _subjectRepository.GetByGuid(id);
            Subject subject = await _subjectRepository.GetByGuidAsync(id);
            if (subject == null)
            {
                response.Success = false;
                return response;
            }
            response.Success = true;
            response.Data = subject;
            return response;
        }

        public async Task<ApiResponse<IEnumerable<Subject>>> GetAllSubjects()
        {
            var response = new ApiResponse<IEnumerable<Subject>>();
            IEnumerable<Subject> subject = await _subjectRepository.GetAllAsyn();
            if (subject == null)
            {
                response.Success = false;
                return response;
            }
            response.Success = true;
            response.Data = subject;
            return response;
        }

        public async Task<ApiResponse<IEnumerable<Subject>>> GetSubjectsByCourseId(Guid id)
        {
            var response = new ApiResponse<IEnumerable<Subject>>();
            List<Subject> subjects = new List<Subject>();
            //subjects based on course id
            ApiResponse<IEnumerable<CourseSubject>> courseSubjects = new ApiResponse<IEnumerable<CourseSubject>>();
            courseSubjects = await _courseSubjectServices.GetSubjectsByCourseId(id);
            foreach(CourseSubject cs in courseSubjects.Data)
            {
                Subject subject = await _subjectRepository.GetByGuidAsync(cs.SubjectId);
                if (subject != null)
                {
                    subjects.Add(subject);
                }
            }

            if (subjects == null)
            {
                response.Success = false;
                return response;
            }
            response.Success = true;
            response.Data = subjects;
            return response;
        }

        public async Task<ApiResponse<Subject>> CreateSubject(SubjectDto subjectDto)
        {
            var response = new ApiResponse<Subject>();
            try
            {
                //check subject Exists
                var isExistSubject = await _subjectRepository.CountAsync(i => i.Name == subjectDto.Name);

                if (isExistSubject != 0)
                {
                    response.Success = false;
                    response.Errors.Add("Subject Already Exists");
                    return response;
                }

                var id = Guid.NewGuid();

                //create new subject
                var subject = Mapper.Map<Subject>(subjectDto);
                subject.Id = id;

                //subject.CreatedBy = subject.Id;
                subject.CreatedDate = DateTime.Now;
                //subject.Roles = subjectRoles;
                subject.IsActive = true;
                await _subjectRepository.AddAsyn(subject);
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
